const fs = require('fs');

const requestHandler = (req, res) => {
    const URL = req.url;
    const METHOD = req.method;

    if (URL === '/') {
        res.write('<!DOCTYPE html><head><html><title>First NodeJS Application | Day 008 | #100DaysOfCode</title></head>');
        res.write('<body>');
        res.write('<form action="/message" method="POST"><input type="text" name="message"><button type="SUBMIT">SUBMIT</button></form>');
        res.write('</body>');
        res.write('</html>');
        // exit out of the function without running code further
        return res.end();
    }

    if(URL === '/message' && METHOD === 'POST') {
        const DATA = [];
        req.on('data', (chuck)=> {
            DATA.push(chuck);
        });

        return req.on('end', ()=>{
            const PARSED_DATA = Buffer.concat(DATA).toString();
            const MESSAGE = PARSED_DATA.split('=')[1];
            fs.writeFileSync('message.txt', MESSAGE);
            res.statusCode = 302;
            res.setHeader('Location', '/');
            return res.end();
        });
    }
}

module.exports = requestHandler;