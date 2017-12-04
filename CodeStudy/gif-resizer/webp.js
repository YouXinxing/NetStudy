'use strict';
const gifsicle = require('gifsicle');
const glob = require('glob');
const path = require('path');
const fs = require('fs');
const sizeOf = require('image-size');
const exec = require('child_process').execSync; 
const rootDir = __dirname

function gif2webp(file) {
    let fileBasename = path.basename(file);
    let fileExtension = path.extname(file);
    let fileBasenameNoExtension = fileBasename.slice(0,-1 * fileExtension.length);

    const input = file;
    const output = `${rootDir}/webp/${fileBasenameNoExtension}.webp`;

    if(!fs.existsSync(output)) {
        let cmd = `gif2webp.exe ${input} -o ${output} -mixed`
        exec(cmd, {'cwd': rootDir});
    }
}


exports.run = function () {
    console.log('run webp')

    var dir = `${rootDir}/webp`
    if (!fs.existsSync(dir)) {
        fs.mkdirSync(dir, 755);
    }

    var l1 = glob.sync(`${rootDir}/src/*.gif`);
    var l2 = glob.sync(`${rootDir}/resize/*.gif`);
    var files = l1.concat(l2)
    // console.log(files)
    files.map(gif2webp);

    console.log('webp finish')
};

if (require.main === module) {
    exports.run();
}