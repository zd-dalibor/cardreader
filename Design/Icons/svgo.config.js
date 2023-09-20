module.exports = {
    js2svg: {
        pretty: true
    },
    plugins: [
        {
            name: 'preset-default',
            params: {
                overrides: {
                    removeViewBox: false
                }
            }
        },
        'removeDimensions'
    ]
}