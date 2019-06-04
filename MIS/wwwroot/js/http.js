function Http() {
  this.http = new XMLHttpRequest();
}

Http.prototype.post = function(url, data) {
  return new Promise((resolve, reject) => {
    this.http.open("POST", url, true);
    //this.http.setRequestHeader(
    //  "Content-type",
    //  "application/x-www-form-urlencoded"
    //  );
    this.http.setRequestHeader("Content-type", "application/json");
    let self = this;
    this.http.onload = () => {
      if (self.http.status === 200) {
        resolve(self.http.responseText);
      } else {
        reject("Error: " + self.http.status);
      }
    };
    this.http.onerror = () => {
      reject("Network Error");
    };
    console.log(JSON.stringify(data));
    this.http.send(JSON.stringify(data));

    //this.http.send(data);
  });
};
