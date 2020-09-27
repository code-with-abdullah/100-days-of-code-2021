const path = require('path');

const express = require('express');

const rootDir = require('../util/path');
const adminData = require('./admin');

const router = express.Router();

router.get('/', (req, res, next) => {
  // res.sendFile(path.join(rootDir, 'views', 'shop.html'));
  const products = adminData.products;
  // res.render('shop', {prods: products, pageTitle: 'shop', path: '/', });   // this will render the shop.pug file

  // => we have to pass a new key-value pair for handlebars to process it
  // res.render('shop', {prods: products, pageTitle: 'shop', path: '/', hasProducts: products.length > 0});   // this will render the shop.pug file

  res.render('shop', {
    prods: products,
    pageTitle: 'shop',
    path: '/',
    hasProducts: products.length > 0,
    productCss:true,
    activeShop:true
  });
});

module.exports = router;
