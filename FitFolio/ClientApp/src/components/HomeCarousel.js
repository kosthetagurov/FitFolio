import React, { Component } from 'react';
import Carousel from 'react-bootstrap/Carousel';

const HomeCarousel = () => {
    return (
        <Carousel style={{ height: "500px" }}>
            <Carousel.Item interval={3000}>
                <img src="\static\carousel\1.jpg" style={{ maxWidth: "100%", height: "auto" }} />
                <Carousel.Caption>
                    <h3>Ваш путь к здоровью и фитнесу</h3>
                    <p>
                        Добро пожаловать в FitFolio! Наше приложение поможет вам достичь лучшей физической формы, отслеживая ваши тренировки и прогресс.
                    </p>
                </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item interval={3000}>
                <img src="\static\carousel\2.jpg" style={{ maxWidth: "100%", height: "auto" }} />
                <Carousel.Caption>
                    <h3>Здоровье - это образ жизни</h3>
                    <p>
                        FitFolio - это не просто приложение, это стиль жизни. Присоединяйтесь к сообществу фитнес-энтузиастов и вдохновляйтесь друг другом на пути к здоровому образу жизни.
                    </p>
                </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item interval={3000}>
                <img src="\static\carousel\3.jpg" style={{ maxWidth: "100%", height: "auto" }} />
                <Carousel.Caption>
                    <h3>Вдохновение везде</h3>
                    <p>
                        С FitFolio вы найдете вдохновение в самых невероятных местах. Вперед, к новым вершинам и достижениям!
                    </p>
                </Carousel.Caption>
            </Carousel.Item>
        </Carousel>
    )
}

export default HomeCarousel