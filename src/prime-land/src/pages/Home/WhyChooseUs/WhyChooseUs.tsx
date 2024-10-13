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
    <Box
      component="section"
      className="whyChooseUs"
      sx={{ margin: '3.5rem 0', paddingTop: '3.5rem' }}
    >
      <Box sx={{ textAlign: 'center', marginBottom: '2rem' }}>
        <Typography
          variant="h2"
          sx={{ textAlign: 'center', marginBottom: '2rem' }}
        >
          TẠI SAO CHỌN CHÚNG TÔI?
        </Typography>
        <Typography variant="body1" maxWidth="768px" margin="auto">
          Với đội ngũ chuyên viên dày dặn kinh nghiệm trong lĩnh vực Bất Động
          Sản, chúng tôi cam kết mang đến những lựa chọn tối ưu, đáp ứng hoàn
          hảo nhu cầu riêng của từng khách hàng.
        </Typography>
      </Box>
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
