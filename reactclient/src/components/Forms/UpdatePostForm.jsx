import { React, useState } from "react";
import { useAuth } from "../../custom/useAuth";
import { FORMS } from "../../constants/forms";
import { modalTransitionDuration } from "../../constants/misc";
import PostsService from "../../api/PostsService";
import Button from "../Helper/Button";
import Modal from "../Helper/Modal";
import "../../styles/components/Form.css";

const UpdatePostForm = (props) => {
	const updatePostForm = FORMS.updatePostForm;
	const [postData, setPostData] = useState({
		title: props.title,
		content: props.content,
	});
	const [message, setMessage] = useState(null);
	const { user } = useAuth();

	const onClose = () => {
		props.onClose();
		setTimeout(() => {
			setMessage(null);
		}, modalTransitionDuration);
	};

	const checkForSameData = () => {
		let hasSameData = false;

		if (postData.title === props.title && postData.content === props.content) {
			setMessage({
				message: "Can't update with same data",
				type: "fail",
			});
			hasSameData = true;
		}

		return hasSameData;
	};

	const checkForEmptyFields = () => {
		let hasEmptyField = false;

		if (postData.title === "") {
			hasEmptyField = true;
			setMessage({
				type: "fail",
				message: "Title can't be empty",
			});
		}

		if (postData.content === "") {
			hasEmptyField = true;
			setMessage({
				type: "fail",
				message: "Content can't be empty",
			});
		}

		return hasEmptyField;
	};

	const onSubmit = async () => {
		let isValidUpdate = !checkForEmptyFields() && !checkForSameData();

		if (isValidUpdate) {
			const postToUpdate = {
				postId: props.postId,
				title: postData.title,
				content: postData.content,
			};

			await PostsService.updatePost(postToUpdate, user.token)
				.then(() => {
					props.onSubmit(postToUpdate);
					setMessage({
						type: "success",
						message: "Post updated successfully",
					});
					setTimeout(() => {
						onClose();
					}, 1000);
				})
				.catch((error) => {
					console.error(error);
					setMessage({
						type: "fail",
						message: "Error during post update",
					});
				});
		}
	};

	return (
		<Modal
			isShown={props.isShown}
			title={updatePostForm.formTitle}
			message={message}
			onClose={() => onClose()}
		>
			<form method={updatePostForm.action} className="form">
				{updatePostForm.formGroups.map((group) => (
					<div key={group.id} className={`form__group ${group.type === "textarea" ? "text" : ""}`}>
						{group.icon}
						{group.type === "textarea" ? (
							<textarea
								id={group.id}
								className="input"
								onChange={(e) =>
									setPostData({ ...postData, [`${group.id}`]: e.currentTarget.value })
								}
								defaultValue={props.content}
								placeholder={group.placeholder}
							/>
						) : (
							<input
								id={group.id}
								type={group.type}
								className="input"
								onChange={(e) =>
									setPostData({ ...postData, [`${group.id}`]: e.currentTarget.value })
								}
								defaultValue={props.title}
								placeholder={group.placeholder}
							/>
						)}
					</div>
				))}

				<div className="form__actions">
					<Button onButtonClick={() => onSubmit()} text="Submit" />
					<Button onButtonClick={() => onClose()} text="Cancel" />
				</div>
			</form>
		</Modal>
	);
};

export default UpdatePostForm;
