import { Component, OnInit } from '@angular/core';
import { GaragesService } from '../../services/garages.service';
import { Garage } from '../../models/garage';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-garages',
  templateUrl: './garages.component.html',
  styleUrls: ['./garages.component.css']
})
export class GaragesComponent implements OnInit {

  // table of garages from government API
  govGarages: Garage[] = [];

  // table of garages from our DB
  dbGarages: Garage[] = [];

  // contains selected garages from government API from Multi Select
  selectedGovGarages: Garage[] = [];

  // columns to display in the tables
  govDisplayedColumns: string[] = ['misparMosah', 'shemMosah', 'yishuv', 'sugMosah'];
  dbDisplayedColumns: string[] = ['misparMosah', 'shemMosah', 'yishuv', 'sugMosah'];

  isLoadingGov = false;
  isLoadingDb = false;

  constructor(private garagesService: GaragesService) {}

  ngOnInit(): void {
    this.loadGovGarages();
    this.loadDbGarages();
  }

  //select data from government API
  loadGovGarages(): void {
    this.isLoadingGov = true;
    this.garagesService.syncFromGov().subscribe({
      next: (data) => {
        this.govGarages = data || [];
        this.isLoadingGov = false;
      },
      error: (err) => {
        console.error('error in getting data', err);
        this.isLoadingGov = false;
      }
    });
  }
  //load data from our DB
  loadDbGarages(): void {
    this.isLoadingDb = true;
    this.garagesService.getAll().subscribe({
      next: (data) => {
        this.dbGarages = data || [];    
        this.isLoadingDb = false;
      },
      error: (err) => {
        console.error('error in loading', err);
        this.isLoadingDb = false;
      }
    });
  }

  // button click - add selected garages from government API to our DB
  onAddClick(): void {
    if (!this.selectedGovGarages || this.selectedGovGarages.length === 0) {
      alert('did not select garages to add');
      return;
    }

    // check which of the selected garages are not already in the DB:
    //by unique key (misparMosah)
    const dbKeys = new Set(
      this.dbGarages.map(g => this.buildGarageKey(g))
    );

    const newGarages = this.selectedGovGarages.filter(g => {
      const key = this.buildGarageKey(g);
      return !dbKeys.has(key);
    });

    // if all selected garages are already in DB-do nothing
    if (newGarages.length === 0) {
      alert('all selected garages are already in the database.');
      return;
    }

    // send requests to add the new garages to the DB
  const requests = newGarages.map(g => {
  const newGarage = { ...g };

  
  delete (newGarage as any)._id;
  delete (newGarage as any).id;
  delete (newGarage as any).Id;

  return this.garagesService.addGarage(newGarage);
});

    forkJoin(requests).subscribe({
      next: (createdList) => {
        //update the local DB table to include the newly added garages
        this.dbGarages = [...this.dbGarages, ...createdList];
        alert('the new garages were added successfully!');
      },
      error: (err) => {
        console.error('error in adding', err);
        alert('there was an error adding the garages.');
      }
    });
  }

  //helps to build a unique key for a garage
  private buildGarageKey(g: Garage): string {
    return `${g.misparMosah}-${g.codMiktzoa}`;
  }
}