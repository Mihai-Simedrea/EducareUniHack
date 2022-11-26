const Connection = require("./connection");
const Connect = new Connection();

class CourseModel extends Connect {
  constructor() {
    super();
    this.UserSchema = this.mongoose.Schema();
  }
}
