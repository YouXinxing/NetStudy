'use strict';
const execFile = require('child_process').execFileSync;
const gifsicle = require('gifsicle');
const fs = require('fs');
const sizeOf = require('image-size');
var program = require('commander');


function resizeGIF(input, output, width) {
    if (!fs.existsSync(output)) {
        var dimensions = sizeOf(input);
        if (dimensions.width > width) {
            execFile(gifsicle, ['-o', output, input,'--resize-width', width, '-O3']);
        } 
    }
}

if (require.main === module) {
    program
      .version('0.0.1')
      .option('-s, --source <source>', 'Source file path')
      .option('-o, --output <output>', 'Output file path')
      .option('-w, --width <width>', 'Resize width')
      .parse(process.argv);

    resizeGIF(program.source, program.output, program.width)
}