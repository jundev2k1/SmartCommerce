// Copyright (c) 2024 - Jun Dev. All rights reserved
import HistoryOutlinedIcon from '@mui/icons-material/HistoryOutlined';

import { whyChooseUsContent } from './whyChooseUs.logic';
import {
  Box,
  Card,
  CardContent,
  Container,
  Grid,
  Typography,
} from '../../../components';
import './WhyChooseUs.scss';

const HomeWhyChooseUs: React.FC = () => {
  return (
    <Box component="section" className="whyChooseUs">
      <Container>
        <Grid container spacing={3}>
          {whyChooseUsContent.map(([title, content], index) => (
            <Grid item md={4} sm={6} key={index}>
              <Card
                className="whyChooseUs__item"
                sx={{ textAlign: 'center', minHeight: '250px' }}
              >
                <CardContent>
                  <Box className="whyChooseUs__item__head">
                    <HistoryOutlinedIcon className="whyChooseUs__item__head__icon" />
                  </Box>
                  <Typography variant="h3" marginBottom={1}>
                    {title}
                  </Typography>
                  <Typography variant="body2">{content}</Typography>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Container>
    </Box>
  );
};

export default HomeWhyChooseUs;
