<%-- 
    Document   : slider
    Created on : May 5, 2020, 11:56:52 PM
    Author     : LENOVO
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<c:url value="/view/client/assets" var="url" />
<section id="aa-slider">
	<div class="aa-slider-area">
		<div id="sequence" class="seq">
			<div class="seq-screen">
				<ul class="seq-canvas">
					<!-- single slide item -->
					<li>
						<div class="seq-model">
							<img data-seq src="${url}/images/nike_slide.png" alt="Men slide img" style="height: 525px;width: 100%"/>
						</div>
						<div class="seq-title">
							<span data-seq>Giảm giá lên đến 50%</span>
							<h2 data-seq>Giày Nike, Adidas</h2>
							<p data-seq></p>
							<a data-seq
								href="${pageContext.request.contextPath}/view/client/product"
								class="aa-shop-now-btn aa-secondary-btn">Xem Sản Phẩm</a>
						</div>
					</li>
					<!-- single slide item -->
					<li>
						<div class="seq-model">
							<img data-seq src="${url}/images/hoaqua_slide.jpg"
								alt="Wristwatch slide img" style="height: 525px;width: 100%"/>
						</div>
						<div class="seq-title">
							<span data-seq>Giảm giá lên đến 20%</span>
							<h2 data-seq>Thực phẩm sạch</h2>
							<p data-seq style="color: black">Rau củ quả được trồng đảm bảo không thuốc hóa học
								từ Vinafarm, đảm bảo chất lương xanh sạch và an toàn.</p>
							<a data-seq
								href="${pageContext.request.contextPath}/view/client/product"
								class="aa-shop-now-btn aa-secondary-btn">Xem Sản Phẩm</a>
						</div>
					</li>
					<!-- single slide item -->
					<li>
						<div class="seq-model">
							<img data-seq src="${url}/images/samsung_slide.png"
								alt="Women Jeans slide img" style="height: 525px;width: 100%"/>
						</div>
						<div class="seq-title">
							<span data-seq>Giảm giá lên đến 33%</span>
							<h2 data-seq>Điện thoại, Máy tính bảng Samsung</h2>
							<p data-seq>Đồng hành cùng Best Price trong tháng tiêu dùng
								của người Việt. Samsung giảm sâu đồ gia dụng và điện thoại di
								động</p>
							<a data-seq
								href="${pageContext.request.contextPath}/view/client/product"
								class="aa-shop-now-btn aa-secondary-btn">Xem Sản Phẩm</a>
						</div>
					</li>
					<!-- single slide item -->
					<li>
						<div class="seq-model">
							<img data-seq src="${url}/images/slide_3.png"
								alt="Shoes slide img" />
						</div>
						<div class="seq-title">
							<span data-seq>Giảm giá lên đến 25%</span>
							<h2 data-seq>Sofa và nội thất Hoàng Nguyên</h2>
							<p data-seq style="color: black">Là sản phẩm được gia công thủ công 100%. Chất
								lượng gỗ cao cấp sang trọng nhưng giá cả lại phù hợp với mọi
								tầng lớp</p>
							<a data-seq
								href="${pageContext.request.contextPath}/view/client/product"
								class="aa-shop-now-btn aa-secondary-btn">Xem Sản Phẩm</a>
						</div>
					</li>
				</ul>
			</div>
			<!-- slider navigation btn -->
			<fieldset class="seq-nav" aria-controls="sequence"
				aria-label="Slider buttons">
				<a type="button" class="seq-prev" aria-label="Previous"><span
					class="fa fa-angle-left"></span></a> <a type="button" class="seq-next"
					aria-label="Next"><span class="fa fa-angle-right"></span></a>
			</fieldset>
		</div>
	</div>
</section>
