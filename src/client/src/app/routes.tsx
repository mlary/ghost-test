import { useMemo } from 'react';
import { Navigate, RouteObject, RouterProvider, createBrowserRouter } from 'react-router-dom';
import AppLayout from '~/components/AppLayout';
import ConfirmRate from '~/pages/ConfirmRate';
import Login from '~/pages/Login';
import Rate from '~/pages/Rate/Rate';
import Recruiter from '~/pages/Recruiter/Recruiter';

const routes: RouteObject[] = [
  {
    path: '/',
    element: <Recruiter />,
  },
  {
    path: '/Login',
    element: <Login />,
  },
  {
    path: '/rate',
    element: <Rate />,
  },
  {
    path: '/confirmation/:rateId/:confirmationId?',
    element: <ConfirmRate />,

  },
];

const AppRouter = () => {
  const router = useMemo(
    () =>
      createBrowserRouter([
        {
          path: '/',
          element: <AppLayout />,
          children: routes,
        },
        {
          path: '*',
          element: <Navigate replace to="/" />,
        },
      ]),
    [],
  );
  return <RouterProvider router={router} />;
};
export default AppRouter;
