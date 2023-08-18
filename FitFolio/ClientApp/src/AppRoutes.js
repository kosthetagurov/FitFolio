import Login from "./Authorization/Login";
import Register from "./Authorization/Register";
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
  }
];

export default AppRoutes;
