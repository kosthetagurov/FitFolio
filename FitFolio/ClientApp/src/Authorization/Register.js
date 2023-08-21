import React, { useState } from "react";
import axios from "axios";
import { Link, Navigate } from "react-router-dom";
import { isAuthenticated } from "./Authorize";

const Registration = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [repassword, setRePassword] = useState("");
    const [errors, setErrors] = useState("");

    const formStyles = {
        width: "60%",
        margin: "0 auto"
    }

    const handleRegister = async () => {
        try {
            const response = await axios.post("/api/auth/register", {
                email,
                password,
                repassword
            });

            const token = response.data.token.result;
            // Сохраните токен в localStorage или cookies
            localStorage.token = token;
            window.location.reload(); 
        } catch (error) {
            var errors = error.response.data;
            setErrors(errors?.map(x => x.description));
        }
    };

    return (isAuthenticated() ? (<Navigate to="/"></Navigate>) :
        <div className="container">
            <h2 className="text-center">Регистрация</h2>
            {errors && errors?.map((item, index) => (
                <p style={{ color: "red" }}>{item}</p>
            ))}
            <form style={formStyles}>
                <div className="form-outline mb-4">
                    <label className="form-label" htmlFor="email">Email</label>
                    <input
                        type="email"
                        className="form-control"
                        placeholder="Введите email"
                        onChange={(e) => setEmail(e.target.value)}
                        id="email"
                    />
                </div>

                <div className="form-outline mb-4">
                    <label className="form-label" htmlFor="passowrd">Пароль</label>
                    <input
                        type="password"
                        className="form-control"
                        placeholder="Введите пароль"
                        onChange={(e) => setPassword(e.target.value)}
                        id="passowrd"
                    />
                </div>

                <div className="form-outline mb-4">
                    <label className="form-label" htmlFor="passowrd">Повторите пароль</label>
                    <input
                        type="password"
                        className="form-control"
                        placeholder="Повторите пароль"
                        onChange={(e) => setRePassword(e.target.value)}
                        id="passowrd"
                    />
                </div>

                

                <div className="text-center">
                    <button type="button" className="btn btn-primary btn-block mb-4" onClick={handleRegister}>Зарегистрироваться</button>
                    <p>Есть аккаунт? <Link to="/login">Войти</Link></p>
                </div>
            </form>            
        </div>
    );
};

export default Registration;
