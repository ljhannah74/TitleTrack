import { Component, OnInit } from '@angular/core';
import { TitleAbstract } from '../../models/title-abstract';
import { TitleAbstractService } from '../title-abstract.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-title-abstract-list',
  imports: [CommonModule],
  templateUrl: './title-abstract-list.component.html',
  styleUrl: './title-abstract-list.component.css',
})
export class TitleAbstractListComponent implements OnInit {
  titleAbstracts: TitleAbstract[] = [];

  constructor(private titleAbstractService: TitleAbstractService) {}

  ngOnInit() {
    this.getTitleAbstracts();
  }

  getTitleAbstracts(): void {
    this.titleAbstractService.getTitleAbstracts().subscribe((data) => {
      this.titleAbstracts = data;
    });
  }
}
