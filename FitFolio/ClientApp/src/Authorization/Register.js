import React, { useState } from "react";
import axios from "axios";

const Registration = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [repassword, setRePassword] = useState("");

    const handleRegister = async () => {
        try {
            const response = await axios.post("/api/auth/register", {
                email,
                password,
                repassword
            });

           console.log(response.data.message);
            // Перенаправьте пользователя на страницу входа или выполните другие действия

        } catch (error) {
            console.error("Ошибка регистрации", error);
        }
    };

    return (
        <div className="container">
            <h2>Регистрация</h2>
            <form>
                <div className="form-group">
                    <label>Email:</label>
                    <input
                        type="email"
                        className="form-control"
                        placeholder="Введите email"
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label>Пароль:</label>
                    <input
                        type="password"
                        className="form-control"
                        placeholder="Введите пароль"
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label>Повторите пароль:</label>
                    <input
                        type="password"
                        className="form-control"
                        placeholder="Повторите пароль"
                        onChange={(e) => setRePassword(e.target.value)}
                    />
                </div>
                <button type="button" className="btn btn-primary" onClick={handleRegister}>Зарегистрироваться</button>
            </form>
        </div>
    );
};

export default Registration;
