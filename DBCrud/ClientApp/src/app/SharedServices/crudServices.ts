import { Injectable } from "@angular/core";
//import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
//import 'rxjs/add/operator/map'
//import 'rxjs/add/operator/catch';
import { ServiceResponse } from "./ServiceResponse"
import { TestimonialDto } from "./testimonialdto"
import { ApiService } from "./api.service"


@Injectable()
export class crudServices {
  constructor( private apiService: ApiService) {
    }
    //get(id): Observable<HotelDetailModel> {
    //    var obj: any = {}
    //    obj.Id = id;

    //    return this.apiService.post(this.configService.hotelDetailUrl, obj)
    //        .map(data => data.Data);
    //}

    //getRoomTypes(id): Observable<ServiceResponse> {
    //    var obj: any = {}
    //    obj.Id = id;
    //    obj.ConversationId = this.conversationTokenService.getConversationToken();
    //    return this.apiService.post(this.configService.roomTypeUrl, obj)
    //        .map(data => data);
    //}
  
    //postandGetSelectedRoomTypeDetails(rooms: ReservedRooms[]): Observable<ServiceResponse> {
    //    var obj: any = {}
    //    obj.reservedRooms = rooms;
    //    obj.ConversationId = this.conversationTokenService.getConversationToken();
    //    return this.apiService.post(this.configService.roomTypeDetailUrl, obj)
    //        .map(data => data);
    //}
  Insert(dto: TestimonialDto): Observable<ServiceResponse> {
    return this.apiService.post("", dto)
            .map(data => data);
    }
}
