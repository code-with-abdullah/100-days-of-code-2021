const http = require('http');

const express = require('express');
const bodyParser = require('body-parser');

const adminRoutes = require('./routes/admin')
const shopRoutes = require('./routes/shop')

const app = express();

const server = http.createServer(app);

app.use(bodyParser.urlencoded({extended:false}));
app.use('/admin',adminRoutes);
app.use(shopRoutes);

app.use((req, res, next)=>{
    res.sendFile(path.join('..', 'views', 'shop.html'));
});

server.listen(3000);