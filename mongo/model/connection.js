const mongoose = require("../node_modules/mongoose");

class Connection {
  constructor() {
    this.mongoose = mongoose
      .connect(
        "mongodb+srv://Stefan:<password>@cluster0.i3vazow.mongodb.net/test/Coruses"
      )
      .then(() => {
        console.log("connected to db");
      });
  }
}

module.exports = Connection;
