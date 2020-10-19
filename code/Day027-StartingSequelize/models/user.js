const Sequelize = require('sequelize');

const sequelize = require('../util/database');

const User = Sequelize.define('user', {
    id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primarykey: true,
        autoIncrement: true
    },
    name: Sequelize.STRING,
    email: Sequelize.STRING
});

module.exports = User;