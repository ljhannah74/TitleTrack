import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, ReactiveFormsModule} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {TitleAbstractService} from '../title-abstract.service';

@Component({
  selector: 'app-title-abstract-details',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './title-abstract-details.component.html',
  styleUrl: './title-abstract-details.component.css'
})
export class TitleAbstractDetailsComponent implements  OnInit {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private service: TitleAbstractService
  ) {
    this.form = this.fb.group({
      titleAbstractID: 0,
      orderNo: [''],
      searchDate: [''],
      effectiveDate: [''],
      propertyAddress: [''],
      productType: [''],
      client: [''],
      clientRefNo: [''],
    });
  }

  ngOnInit(): void {
  }

  save() {
    console.log(this.form.value);

    this.service.createTitleAbstract(this.form.value).subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.error("Error creating title abstract: ", error)
      },
    });
  }
}

