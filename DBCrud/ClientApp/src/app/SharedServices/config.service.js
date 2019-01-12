"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
let ConfigService = class ConfigService {
    constructor() {
        this.apiUrl = 'http://localhost:2814/';
        this.homeSliderUrl = this.apiUrl + "homepage/get-sliders";
        this.hotelSearchUrl = this.apiUrl + "hotel/search";
        this.companyDetails = this.apiUrl + "homepage/get-companyDetails";
        this.galleryUrl = this.apiUrl + "homepage/get-gallery";
        this.hotelDestinationsUrl = this.apiUrl + "hotel/destination";
        this.faqUrl = this.apiUrl + "homepage/faq";
        //shared
        this.timeZoneUrl = this.apiUrl + "sharedService/timeZone";
        this.paxTypeUrl = this.apiUrl + "sharedService/paxType";
        this.titleNameUrl = this.apiUrl + "sharedService/titleNames";
        //Authentication
        this.signInUrl = this.apiUrl + "account/Authenticate";
        this.registerUrl = this.apiUrl + "user/register";
        this.getProfile = this.apiUrl + "user/getProfile";
        this.getbalance = this.apiUrl + "User/get-balance";
        this.updateProfile = this.apiUrl + "User/update-profile";
        this.logoutUrl = this.apiUrl + "user/logout";
        this.changePasswordUrl = this.apiUrl + "user/change-user-password";
        //searchResult
        this.filterOption = this.apiUrl + "hotel/filter-options";
        this.filterUrl = this.apiUrl + "hotel/filter";
        //hotelDetails
        this.hotelDetailUrl = this.apiUrl + "hotel/details/";
        this.roomTypeUrl = this.apiUrl + "hotel/room-types";
        this.roomTypeDetailUrl = this.apiUrl + "hotel/roomtype-details";
        this.bookNowUrl = this.apiUrl + "room/book";
        this.myRoomBookingDetailUrl = this.apiUrl + "my/booking-details";
        this.myBookingsUrl = this.apiUrl + "my/bookings";
    }
    getApiUri() {
        return this.apiUrl;
    }
    getApiHost() {
        return this.apiUrl.replace('api/', '');
    }
};
ConfigService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [])
], ConfigService);
exports.ConfigService = ConfigService;
//# sourceMappingURL=config.service.js.map