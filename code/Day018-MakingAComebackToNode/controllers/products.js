const Product = require('../models/product')

exports.getAddProduct = (req, res, next) => {
    res.render('add-product', {
        pageTitle: 'shop',
        path: '/admin/add-product',
        productCss:true,
        formsCss:true,
        activeAddProduct:true
    });
}

exports.postAddProduct = (req, res, next) => {
    //''st Product = new Product[req.pageTitle]|
    res.redirect('/');
}

exports.getProducts = (req, res, next) => {
        res.render('shop', {
        prods: products,
        pageTitle: 'shop',
        path: '/',
        hasProducts: products.length > 0,
        productCss:true,
        activeShop:true
    });
}