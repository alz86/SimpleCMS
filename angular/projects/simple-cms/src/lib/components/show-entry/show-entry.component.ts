import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ContentEntryService } from '@proxy/controllers';
import { ContentEntryDto } from '@proxy/dto';
import { switchMap } from 'rxjs';

@Component({
  selector: 'lib-show-entry',
  standalone: true,
  imports: [],
  templateUrl: './show-entry.component.html',
  styleUrl: './show-entry.component.css',
})
export class ShowEntryComponent implements OnInit {
  constructor(
    private readonly route: ActivatedRoute,
    private readonly service: ContentEntryService
  ) {}

  public entry: ContentEntryDto;

  ngOnInit(): void {
    this.route.paramMap
      .pipe(
        switchMap((params: ParamMap) => {
          const id = params.get('id');
          return this.service.getCMSContentByEntryId(id);
        })
      )
      .subscribe(result => {
        this.entry = result;
      });
  }
}
