import express from "express";
import path from "path";

const app = express();
const PORT = 5000;

// Servire file statici (HTML, CSS, JS)
app.use(express.static(path.join(__dirname, "../public")));

app.get("/", (req, res) => {
    res.sendFile(path.join(__dirname, "../public/index.html"));
});

app.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}`);
});
