<%-- 
    Document   : index
    Created on : May 5, 2020, 10:57:00 PM
    Author     : LENOVO
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<c:url value="/view/client/assets" var="url" />


<!-- Start header section -->
<jsp:include page="./header/mainHeader.jsp" flush="true" />
<!-- / header section -->

<!--  content -->
<!-- catg header banner section -->
<section id="aa-catg-head-banner">
	<img
		src="${pageContext.request.contextPath}/view/client/assets/images/blog-banner.jpg"
		alt="banner liên hệ">
	<div class="aa-catg-head-banner-area">
		<div class="container">
			<div class="aa-catg-head-banner-content">
				<h2>Liên hệ</h2>
				<ol class="breadcrumb">
					<li><a href="${pageContext.request.contextPath}/">Trang
							chủ</a></li>
					<li style="color: #fff">Thông tin liên hệ</li>
				</ol>
			</div>
		</div>
	</div>
</section>
<!-- / catg header banner section -->
<!-- start contact section -->
<section id="aa-contact">
	<div class="container">
		<div class="row">
			<div class="col-md-12">
				<div class="aa-contact-area">
					<div class="aa-contact-top">
						<h2>Hỗ trợ tận tình 24/7...</h2>
						<p>Tiếp nhận và phản hồi mọi ý kiến và thắc mắc từ khách hàng.</p>
					</div>

					<!-- Contact address -->
					<div class="aa-contact-address">
						<div class="row">
							<div class="col-md-7">
								<div class="aa-contact-map">
									<iframe
										src="https://maps.google.com/maps?q=Đại học Giao thông Vận tải, số 3 Cầu Giấy&t=&z=13&ie=UTF8&iwloc=&output=embed"
										width="100%" height="450" frameborder="0" style="border: 0;"
										allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
								</div>
							</div>
							<div class="col-md-5">
								<div class="aa-contact-address-right">
									<address>
										<h4>Best Price</h4>
										<p>Liên hệ cho chúng tôi:</p>
										<p>
											<span class="fa fa-home"></span>Best Price Việt Nam, Số 3, Cầu Giấy, Láng Thượng, Đống Đa, Hà Nội
										</p>
										<p>
											<span class="fa fa-phone"></span>037.3405.234
										</p>
										<p>
											<span class="fa fa-envelope"></span>Email:
											contact@bestprice.com.vn
										</p>
									</address>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</section>
<!--  end content-->

<!--  footer-->
<jsp:include page="./footer/footer.jsp" flush="true" />
<!-- end footer-->



