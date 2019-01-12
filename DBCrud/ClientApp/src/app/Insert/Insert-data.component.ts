import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl, FormArray } from "@angular/forms";
import { ApiService } from '../sharedServices/api.service';
import { TestimonialDto } from "../SharedServices/testimonialDto"
import { ServiceResponse, Messages } from "../SharedServices/ServiceResponse"
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute } from "@angular/router"
import { MessageService } from "../sharedservices/messageservice";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './Insert-data.component.html'
})
export class InsertDataComponent implements OnInit {
  public forecasts: WeatherForecast[];
  createForm: FormGroup;
  rootUrl: string;
  id: number; title: string = "Create";
  errorMessage: Messages[];
  constructor(private router: Router,http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fb: FormBuilder
    , private apiService: ApiService, private _avRoute: ActivatedRoute, private messageService: MessageService) {
    if (this._avRoute.snapshot.params["id"]) {
      this.id = this._avRoute.snapshot.params["id"];
    }

    this.rootUrl = baseUrl;
    this.createForm = this.fb.group({
      id: 0,
      email: new FormControl('', [Validators.required, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+')]),
      title: new FormControl('', Validators.required),
      descriptions: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      isActive: false
    });
  }
  ngOnInit() {
    if (this.id > 0) {
      this.title = "Edit";
      this.apiService.get(this.rootUrl + "v1/testimonial/get/" + this.id)
        .subscribe(resp => this.createForm.setValue(resp.data)
          , error => this.errorMessage = error);
    }
  }

  insert(form: NgForm) {
    if (!this.createForm.valid) {
      return;
    }
   
    if (this.title === "Create") {
      this.postdata(this.rootUrl + "/v1/testimonial/insert",form.value).subscribe(
        (resp) => {
          if (resp.status) {
            this.messageService.changeMessage(resp.messages);
            this.router.navigate(['/fetch-data/']);
          } else {
            this.errorMessage = resp.messages;
          }
        }
      );
    } else if (this.title === "Edit") {
      this.postdata(this.rootUrl + "/v1/testimonial/update",form.value).subscribe(
        (resp) => {
          if (resp.status) {
            this.messageService.changeMessage(resp.messages);
            this.router.navigate(['/fetch-data/']);
          } else {
           
            this.errorMessage = resp.messages;
          }
        }
      );
    }
  }
  postdata(url:string,dto: TestimonialDto): Observable<ServiceResponse> {
   
    return this.apiService.post(url, dto)
      .map(data => data);
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
