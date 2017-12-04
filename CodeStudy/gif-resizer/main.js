'use strict';
const execFile = require('child_process').execFile;
const resize = require(`./resize.js`);
const webp = require(`./webp.js`);

resize.run()
webp.run()

