import { ThemeProvider } from '@mui/material/styles';
import AppRouter from './routes';
import { DEFAULT_THEME } from './theme';

const App = () => {
  return (
    <ThemeProvider theme={DEFAULT_THEME}>
      <AppRouter />
    </ThemeProvider>
  );
};

export default App;
