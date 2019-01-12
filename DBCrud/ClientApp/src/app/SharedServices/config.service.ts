export class ConfigService {

  //shared
  insertUrl: string;
  fetchdataUrl: string;
  editUrl: string;
  deleteUrl: string;
  baseUrl:string;


  constructor() {
    //shared
    this.baseUrl = "";
    this.insertUrl = this.baseUrl + "v1/testimonial/insert";
    this.fetchdataUrl = this.baseUrl + "v1/testimonial/getall";
    this.editUrl = this.baseUrl + "v1/testimonial/update";
    this.deleteUrl = this.baseUrl + "v1/testimonial/delete";


  }

  //getApiUri() {
  //  return this.apiUrl;
  //}

  //getApiHost() {
  //  return this.apiUrl.replace('api/', '');
  //}
}
