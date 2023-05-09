const express = require('express')
const app = express()
const port = 3000
const config = {
    host: 'db',
    user: 'root',
    password: 'root',
    database: 'desafionodejs'
};

const mysql = require('mysql')



// connection.end()
app.get('/', (req, res) => {
    let toSend = '<h1>Full cycle</h1>';
    const connection = mysql.createConnection(config);
    connection.connect(function (err) {
        if (err) throw err;
        connection.query("SELECT * FROM people;", function (err, result) {
            if (err) throw err;
            for (let index = 0; index < result.length; index++) {
                const element = result[index];

                toSend += '<h1>' + element.name + '</h1>';
            }

            res.send(toSend);
        });
    });
})

app.listen(port, () => {
    console.log('Rodando na porta ' + port);
})