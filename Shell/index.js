// const hostname = '192.168.0.107';
const hostname = '192.168.0.108';
const express = require("express");
const bodyParser = require('body-parser')

const app = express();
const router = express.Router();

app.set("view engine", "ejs");
app.use(express.static(__dirname + '/content'));
app.use(bodyParser.urlencoded({ extended: true }));

const login = require('./routers/login_controller');
router.get("/login", login.get);
router.post("/login", login.post);

const register = require('./routers/register_controller');
router.post("/register", register.post);

app.get("/", function(request, response){
    response.render("index");
});

app.use("/", router);

app.listen(3000, hostname);