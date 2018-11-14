
//  config: Config; 
  
// showConfig() {
//     this.configService.getConfig()
//       .subscribe((data: Config) => this.config = {
//           heroesUrl: data[''],
//           textfile:  data['textfile']
//       },error => this.error = error);
//   }
//   showConfigResponse() {
//     this.configService.getConfigResponse()
//       // resp is of type `HttpResponse<Config>`
//       .subscribe(resp => {
//         // display its headers
//         const keys = resp.headers.keys();
//         this.headers = keys.map(key =>
//           `${key}: ${resp.headers.get(key)}`);
  
//         // access the body directly, which is typed as `Config`.
//         this.config = { ... resp.body };
//       });
//   }