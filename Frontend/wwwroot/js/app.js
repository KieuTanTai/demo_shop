import { Student } from "./Student/Student.js";
export default function TSButton() {
    let name = "Freya";
    const element = document.getElementById("ts-example");
    if (element) {
        element.innerHTML = greeter(user);
    }
}
function greeter(person) {
    return "Hello, " + person.firstName + " " + person.lastName + "!!!";
}
let user = new Student("Fred", "M.", "Smith");
document.addEventListener("DOMContentLoaded", () => {
    const btn = document.getElementById("ts-btn");
    if (btn) {
        btn.addEventListener("click", TSButton);
    }
});
//# sourceMappingURL=app.js.map