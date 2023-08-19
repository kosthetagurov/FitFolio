import React, { useState } from "react";
import axios from "axios";
import { Navigate } from "react-router-dom";
import { isAuthenticated } from "./Authorize";

const Registration = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [repassword, setRePassword] = useState("");
    const [errors, setErrors] = useState("");

    const handleRegister = async () => {
        try {
            const response = await axios.post("/api/auth/register", {
                email,
                password,
                repassword
            });
            debugger;
            const token = response.data.token.result;
            // Сохраните токен в localStorage или cookies
            localStorage.token = token;
            window.location.reload(); 
        } catch (error) {
            debugger;
            var errors = error.response.data;
            setErrors(errors?.map(x => x.description));
        }
    };

    return (isAuthenticated() ? (<Navigate to="/"></Navigate>) :
        <div className="container">
            <h2>Регистрация</h2>
            {errors && errors?.map((item, index) => (
                <p style={{ color: "red" }}>{item}</p>
            ))}
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
