const path = require('path');

const express = require('express');
const bodyParser = require('body-parser');
// const hbs = require('express-handlebars');

const app = express();

// => used to register pug as templating engine
// app.set('view engine', 'pug');  // setting PUG as the templating engine
// app.set('views', 'views');      // setting the file where views are saved

// => used to register handlebars as templating engine
//app.set('views', 'views');      // setting the file where views are saved/
// app.engine('hbs', hbs({layoutsDir:'views/layouts', defaultLayout:'main-layout', extname: 'hbs'}));
//app.set('view engine', 'hbs');

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
    //res.status(404).sendFile(path.join(__dirname, 'views', '404.html'));

    // => used for templating engine
    res.render('404', {pageTitle: '404 error | Page not found', path: req.url});
});

app.listen(3000);