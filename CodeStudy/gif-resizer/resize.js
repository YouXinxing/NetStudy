'use strict';
const execFile = require('child_process').execFileSync;
const gifsicle = require('gifsicle');
const glob = require('glob');
const path = require('path');
const fs = require('fs');
const sizeOf = require('image-size');
const rootDir = __dirname

function resizeGIF(file) {

    const sizes = [
        { suffix: '_200', width: 200 },
        { suffix: '_480', width: 480 }
    ];

    sizes.map(size => {                    
        let fileBasename = path.basename(file);
        let fileExtension = path.extname(file);
        let fileBasenameNoExtension = fileBasename.slice(0,-1 * fileExtension.length);

        const input = `${rootDir}/src/${fileBasename}`;
        const output = `${rootDir}/resize/${fileBasenameNoExtension}${size.suffix}${fileExtension}`;

        // const fse = require('fs-extra');
        // fse.copySync(input, `resize/${fileBasename}`)

        if (!fs.existsSync(output)) {
            var dimensions = sizeOf(input);
            if (dimensions.width > size.width) {
                //gifsicle used for resizing the input. -o is the oporation send output to file  and -03 is the maximum gif optimization level
                execFile(gifsicle, ['-o', output, input,'--resize-width', size.width, '-O3']);
            } 
        }
    });
}

exports.run = function (url) {
    console.log('run resize')

    var dir = `${rootDir}/resize`
    if (!fs.existsSync(dir)) {
        fs.mkdirSync(dir, 755);
    }

    let files = glob.sync(`${rootDir}/src/*.gif`);
    files.map(resizeGIF);
    
    console.log('resize finish')
};

if (require.main === module) {
    exports.run();
}