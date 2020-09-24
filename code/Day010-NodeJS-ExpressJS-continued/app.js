const http = require('http');

const express = require('express');
const bodyParser = require('body-parser');

const adminRoutes = require('./routes/admin')
const shopRoutes = require('./routes/shop')

const app = express();

const server = http.createServer(app);

app.use(bodyParser.urlencoded({extended:false}));

app.use(adminRoutes);

app.use(shopRoutes);

server.listen(3000);