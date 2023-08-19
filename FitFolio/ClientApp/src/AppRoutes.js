import Login from "./Authorization/Login";
import Register from "./Authorization/Register";
import Counter from "./components/Counter";
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/login',
        element: <Login />
    },
    {
        path: '/register',
        element: <Register />
    },
    {
        path: '/counter',
        element: <Counter />
    }
];

export default AppRoutes;
