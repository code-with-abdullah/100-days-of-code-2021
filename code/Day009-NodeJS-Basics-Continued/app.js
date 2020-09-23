const http = require('http');

const express = require('express');
const bodyParser = require('body-parser');

const app = express();

const server = http.createServer(app);

app.use(bodyParser.urlencoded({extended:false}));

app.use('/add-product', (req, res, next) => {
    res.send('<form action="/product" method="POST"><input type="text" name="title"><button type="SUBMIT">SUBMIT</button></form>');
});

app.post('/product', (req, res, next)=>{
    console.log(req.body["title"]);
    res.redirect('/');
});

app.use('/', (req, res, next) => {
    res.send('<h1>Express application</h1>');
});

server.listen(3000);