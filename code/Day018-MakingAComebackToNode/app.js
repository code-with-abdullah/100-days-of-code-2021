const path = require('path');

const express = require('express');
const bodyParser = require('body-parser');

const app = express();

// => used to register ejs as templating engine
app.set('view engine', 'ejs');
app.set('views', 'views');

const shopRoutes = require('./routes/shop');
const adminRoutes = require('./routes/admin');
const errorController = require('./controllers/errors');

app.use(bodyParser.urlencoded({extended: false}));
app.use(express.static(path.join(__dirname, 'public')));

app.use('/admin', adminRoutes);

app.use(shopRoutes);

// handling 404 error
app.use(errorController.get404Page);

app.listen(3000);