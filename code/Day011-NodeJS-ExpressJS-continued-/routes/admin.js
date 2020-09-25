const path = require('path');

const express = require('express');
const rootDirectory = require(path.join('..', 'util', 'path'));

const router = express.Router();

router.get('/add-product', (req, res, next) => {
    res.sendFile(path.join(rootDirectory, '..', 'views', 'shop.html'));
});

router.post('/product', (req, res, next)=>{
    console.log(req.body["title"]);
    res.redirect('/');
});

module.exports = router;