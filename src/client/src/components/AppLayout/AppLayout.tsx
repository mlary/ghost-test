/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Suspense } from 'react';
import { Outlet, useLocation } from 'react-router';
import AppFooter from '../AppFooter/AppFooter';
import AppHeader from '../AppHeader/AppHeader';
import Spinner from '../Spinner';

const classes = {
  root: css({
    display: 'flex',
    flexFlow: 'column nowrap',
    height: '100vh',
    width: '100vw',
    backgroundColor: 'var(--bg-main)',
    overflow: 'none',
    overflowY: 'auto',
  }),
  container: css({
    display: 'block',
    position: 'relative',
    padding: 16,
    '@media (max-width: 600px)': css({
      padding: 2,
    }),
  }),
};

const AppLayout = () => {
  const { pathname } = useLocation();
  const showHeader = pathname.toUpperCase() === '/LOGIN';
  return (
    <div css={classes.root}>
      {!showHeader && <AppHeader />}
      <div css={classes.container}>
        <Suspense fallback={<Spinner size={100} />}>
          <Outlet />
        </Suspense>
      </div>
      <AppFooter />
    </div>
  );
};
export default AppLayout;
