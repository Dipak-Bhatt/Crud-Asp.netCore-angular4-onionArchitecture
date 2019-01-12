import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TestimonialDto } from '../sharedservices/testimonialdto';
import { ApiService } from '../sharedServices/api.service';
import { Observable } from 'rxjs/Observable';
import { ServiceResponse, Messages} from '../SharedServices/ServiceResponse';
import { MessageService } from "../sharedservices/messageservice";

@Component({
  selector: 'app-testimonials-data',
  templateUrl: './fetch-testimonials.component.html'
})
export class FetchTestimonialsComponent {
  public testimonials: TestimonialDto[];
  rootUrl: string;
  message: Messages[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private apiService: ApiService, private messageService: MessageService) {
    this.rootUrl = baseUrl;
    this.messageService.currentMessage.subscribe(message => this.message = message);

    this.getAll().subscribe(data => {
       
      this.testimonials = data.data;
      console.log(this.testimonials);
      },
      error => {
        console.log(error);
      });
  }
  getAll(): Observable<ServiceResponse> {
    return this.apiService.get(this.rootUrl + "/v1/testimonial/getall")
      .map(data => data);
  }
  deleteRow(id) {
    this.apiService.delete(this.rootUrl + "v1/testimonial/delete/"+id)
      .subscribe(
        response => {
          if (response.status) {
            this.getAll().subscribe(data => {

                this.testimonials = data.data;
                console.log(this.testimonials);
              },
              error => {
                console.log(error);
              });
          }

        },
        error => {
         // this.errorMessage = <any>error;
        }
      );
  }
}
