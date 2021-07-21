// const hostname = '192.168.0.107';
const hostname = '192.168.0.108';
const express = require("express");
const bodyParser = require('body-parser')

const app = express();

app.set("view engine", "ejs");
app.use(express.static(__dirname + '/content'));

app.use(bodyParser.urlencoded({ extended: true }));

app.get("/", function(request, response){
    response.render("index");
});

app.post('/', function(req, res, next){
    console.log(req.body.login);
});

app.listen(3000,hostname);