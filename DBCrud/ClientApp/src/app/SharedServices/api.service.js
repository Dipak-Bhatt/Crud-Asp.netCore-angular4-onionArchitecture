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
/// <reference path="../authservices/jwt.service.ts" />
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
const Rx_1 = require("rxjs/Rx");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
const jwt_service_1 = require("../authservices/jwt.service");
let ApiService = class ApiService {
    constructor(http, jwtService) {
        this.http = http;
        this.jwtService = jwtService;
    }
    setHeaders() {
        //const headersConfig = {
        //  'Content-Type': 'application/json',
        //  'Accept': 'application/json'
        //};
        //if (this.jwtService.getToken()) {
        //  headersConfig['Authorization'] = this.jwtService.getToken();
        //    headersConfig['Authorization'] = this.jwtService.getToken();
        //}
        //return new Headers(headersConfig);
        let headers = new http_1.Headers();
        headers.append('Content-Type', 'application/json ');
        headers.append('Accept', 'application/json ');
        headers.append('Token', this.jwtService.getToken());
        headers.append('DeviceId', this.jwtService.getClientId());
        return headers;
    }
    formatErrors(error) {
        return Rx_1.Observable.throw(error.json());
    }
    get(path, params = new http_1.URLSearchParams()) {
        return this.http.get(path, { headers: this.setHeaders(), search: params })
            .catch(this.formatErrors)
            .map((res) => res.json());
    }
    put(path, body = {}) {
        return this.http.put(path, JSON.stringify(body), { headers: this.setHeaders() })
            .catch(this.formatErrors)
            .map((res) => res.json());
    }
    post(path, body = {}) {
        return this.http.post(path, JSON.stringify(body), { headers: this.setHeaders() })
            .catch(this.formatErrors)
            .map((res) => res.json());
    }
    delete(path) {
        return this.http.delete(path, { headers: this.setHeaders() })
            .catch(this.formatErrors)
            .map((res) => res.json());
    }
};
ApiService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        jwt_service_1.JwtService])
], ApiService);
exports.ApiService = ApiService;
//# sourceMappingURL=api.service.js.map