const path = require('path');

const express = require('express');

const rootDirectory = require(path.join('..', 'util', 'path'));

const router = express.Router();

router.get('/', (req, res, next) => {
    res.sendFile(path.join(rootDirectory, '..', 'views', 'shop.html'));
});

module.exports = router;