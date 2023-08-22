import React, { Component } from 'react';
import HomeCarousel from './HomeCarousel.js'
import { Link } from "react-router-dom";

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div className="row">
                <div className="col-lg-4" style={{ fontSize: "18px" }}>
                    <p style={{textAlign: "justify"}}>
                        FitFolio - это приложение, созданное для эффективного ведения дневника тренировок и точного отслеживания прогресса в тренажерном зале.
                        С его помощью каждый фитнес-энтузиаст сможет достичь новых высот в своей физической форме и достижениях.
                        Персонализированные тренировки, советы от опытных тренеров, поддержка сообщества и удобный мониторинг вашего прогресса - всё это в одном мощном инструменте.
                        Начните свой путь к здоровью и лучшей форме с FitFolio уже сегодня!
                    </p>
                    <br />
                    <p>
                        Уже есть аккаунт? <Link to="login">Войти</Link>
                        <br />
                        Нет аккаунта? <Link to="/register">Зарегистрироваться</Link>
                    </p>
                </div>
                <div className="col-lg-8">
                    <HomeCarousel />
                </div>                
            </div>            
        );
    }
}
