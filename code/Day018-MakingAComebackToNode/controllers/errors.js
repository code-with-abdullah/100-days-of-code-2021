exports.error404Page = (req, res, next) => {
    res.render('404', {
        pageTitle: '404 error | Page not found',
        path: req.url
    });
}