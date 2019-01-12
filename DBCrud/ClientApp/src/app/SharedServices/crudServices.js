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
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
const router_1 = require("@angular/router");
const config_service_1 = require("../config.service");
const api_service_1 = require("../services/api.service");
const conversationtoken_service_1 = require("../services/conversationtoken.service");
let HotelDetailServices = class HotelDetailServices {
    constructor(router, configService, apiService, conversationTokenService) {
        this.router = router;
        this.configService = configService;
        this.apiService = apiService;
        this.conversationTokenService = conversationTokenService;
    }
    get(id) {
        var obj = {};
        obj.Id = id;
        return this.apiService.post(this.configService.hotelDetailUrl, obj)
            .map(data => data.Data);
    }
    getRoomTypes(id) {
        var obj = {};
        obj.Id = id;
        obj.ConversationId = this.conversationTokenService.getConversationToken();
        return this.apiService.post(this.configService.roomTypeUrl, obj)
            .map(data => data);
    }
    getRoomTypeDetails(id) {
        var obj = {};
        obj.HotelRoomTypeId = id;
        obj.ConversationId = this.conversationTokenService.getConversationToken();
        return this.apiService.post(this.configService.roomTypeDetailUrl, obj)
            .map(data => data);
    }
    postandGetSelectedRoomTypeDetails(rooms) {
        var obj = {};
        obj.reservedRooms = rooms;
        obj.ConversationId = this.conversationTokenService.getConversationToken();
        return this.apiService.post(this.configService.roomTypeDetailUrl, obj)
            .map(data => data);
    }
    bookNow(roombookReq) {
        roombookReq.conversationId = this.conversationTokenService.getConversationToken();
        return this.apiService.post(this.configService.bookNowUrl, roombookReq)
            .map(data => data);
    }
};
HotelDetailServices = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [router_1.Router, config_service_1.ConfigService, api_service_1.ApiService, conversationtoken_service_1.ConversationTokenService])
], HotelDetailServices);
exports.HotelDetailServices = HotelDetailServices;
//# sourceMappingURL=hoteldetailservices.js.map