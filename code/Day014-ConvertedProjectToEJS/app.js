const path = require('path');

const express = require('express');
const bodyParser = require('body-parser');

const app = express();

// => used to register ejs as templating engine
app.set('view engine', 'ejs');
app.set('views', 'views');

const adminData = require('./routes/admin');
const shopRoutes = require('./routes/shop');

app.use(bodyParser.urlencoded({extended: false}));
app.use(express.static(path.join(__dirname, 'public')));

app.use('/admin', adminData.routes);
app.use(shopRoutes);

// handling 404 error
app.use((req, res, next) => {
    // => used for templating engine
    res.render('404', {
        pageTitle: '404 error | Page not found',
        path: req.url
    });
});

app.listen(3000);