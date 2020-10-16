const Sequelize = require('sequelize');

const sequelize = new Sequelize('node-complete', 'root', 'admin',{
    dialect: 'myql',
    host: 'localhost'
});

module.exports = sequelize;