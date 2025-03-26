const express = require('express');
const app = express();
const port = 5000;

app.get('/', (req, res) => {
<<<<<<< HEAD
    res.status(200).sendFile('index.html', {root: __dirname});
=======
    res.stauts(200).sendFile('index.html', {root: __dirname});
>>>>>>> 30ec16b1422bbd206727c77ed2f5722cd9d05876
});

app.listen(port, () => {
    console.log(`Now listening on port ${port}`); 
});