const http = require("http");
const querystring = require("querystring");

const post = (req, res, next) => {
    var data = querystring.stringify({
        Command: "RegistrationHandler",
        e: req.body.email,
        l: req.body.login,
        n: req.body.fullName,
        p: req.body.password
    });

    var options = {
        // host: '192.168.0.107',
        host: '127.0.0.1',
        port: 3001,
        path: '/request',
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Content-Length': Buffer.byteLength(data)
        }
    };

    var request1 = http.request(options, function(res)
    {
        res.setEncoding('utf8');
        res.on('data', function (chunk) {
            console.log("body: " + chunk);
        });
    });

    request1.write(data);
    request1.end();
}

module.exports = {post};